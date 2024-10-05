using System;
using System.Collections.Generic;
using System.Linq;
using Insurance_Management_System.Entity;
using Insurance_Management_System.util;
using System.Data.SqlClient;
using Insurance_Management_System.exception;

namespace Insurance_Management_System.dao
{
    internal class InsuranceServiceImpl : IPolicyService
    {
        
        private List<Policy> policyDatabase = new List<Policy>();

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public InsuranceServiceImpl()
        {
            sqlConnection = DBConnection.getConnection();
            cmd = new SqlCommand();
        }

        
        public bool CreatePolicy(Policy policy)
        {
            try
            {
                cmd.CommandText = "Insert Into Policy values()";
                cmd.Parameters.AddWithValue("@policyId", policy.PolicyId);
                cmd.Parameters.AddWithValue("@policyName", policy.PolicyName);
                cmd.Parameters.AddWithValue("@policyDetails", policy.PolicyDetails);
                cmd.Parameters.AddWithValue("@premiumAmount", policy.PremiumAmount);
                cmd.Parameters.AddWithValue("@clientId", policy.ClientId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int status = cmd.ExecuteNonQuery();
                return status==1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating policy: {ex.Message}");
                return false; 
            }
        }


        public Policy GetPolicy(int policyId)
        {
            try
            {
                Policy policy=null;
                cmd.CommandText = "select * from policy where policyId = " + policyId;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    policy = new Policy();
                    policy.PolicyId = (int)reader["policyId"];
                    policy.PolicyName = (string)reader["policyName"];
                    policy.PolicyDetails = (string)reader["policyDetails"];
                    policy.PremiumAmount = (double)reader["premiumAmount"];
                    policy.ClientId = (int)reader["clientId"];
                }
                if (policy == null)
                    throw new PolicyNotFoundException("Policy not found");
                return policy;
            }
            catch(PolicyNotFoundException px)
            {
                Console.WriteLine(px.ToString());
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving policy: {ex.Message}");
                return null; 
            }
        }

        public List<Policy> GetAllPolicies()
        {
            try
            {
                List<Policy> policies = new List<Policy>();
                Policy policy;
                cmd.CommandText = "select * from policy where policyId";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    policy = new Policy();
                    policy = new Policy();
                    policy.PolicyId = (int)reader["policyId"];
                    policy.PolicyName = (string)reader["policyName"];
                    policy.PolicyDetails = (string)reader["policyDetails"];
                    policy.PremiumAmount = (double)reader["premiumAmount"];
                    policy.ClientId = (int)reader["clientId"];
                    policies.Add(policy);
                }
                return policies;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving policy: {ex.Message}");
                return null; 
            }
        }


        public bool UpdatePolicy(Policy policy)
        {
            return false;
        }


        public bool DeletePolicy(int policyId)
        {
            try
            {
           
                cmd.CommandText = "delete from Policy where policyId=" + policyId;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int status = cmd.ExecuteNonQuery();
                return status == 1;
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting policy: {ex.Message}");
                return false;
            }

        }

        public bool login(string username, string password)
        {
            try
            {

                cmd.CommandText = "select password from Userdetails where userName = " + username;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string pwd = (string)reader["password"];
                    if (string.Equals(pwd, password)) return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("login failed");
                return false;
            }
        }
    }
}


