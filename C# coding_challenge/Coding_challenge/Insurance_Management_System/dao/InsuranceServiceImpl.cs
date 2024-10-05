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
        SqlCommand cmd = null;

        public InsuranceServiceImpl()
        {

        }


        public bool CreatePolicy(Policy policy)
        {
            try
            {
                using (var sqlConnection = DBConnection.getConnection())
                {
                    string query = "Insert Into Policy(policyName, policyDetails, premiumAmount,clientid) values(@policyId,@policyName,@policyDetails,@premiumAmount,@clientId)";
                    cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@policyName", policy.PolicyName);
                    cmd.Parameters.AddWithValue("@policyDetails", policy.PolicyDetails);
                    cmd.Parameters.AddWithValue("@premiumAmount", policy.PremiumAmount);
                    cmd.Parameters.AddWithValue("@clientId", policy.ClientId);
                    sqlConnection.Open();
                    int status = cmd.ExecuteNonQuery();
                    return status > 0;
                }
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
                using (var sqlConnection = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Policies WHERE PolicyId = @PolicyId";
                    cmd = new SqlCommand(query, sqlConnection);
                    Policy policy = null;
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
            }
            catch (PolicyNotFoundException px)
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
                using (var sqlConnection = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Policies";
                    cmd = new SqlCommand(query, sqlConnection);
                    List<Policy> policies = new List<Policy>();
                    Policy policy;
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving policy: {ex.Message}");
                return null;
            }
        }


        public bool UpdatePolicy(Policy policy)
        {
            using (var connection = DBConnection.getConnection())
            {

                string query = "UPDATE Policies SET PolicyName = @PolicyName, PolicyDetails = @PolicyDetails, PremiumAmount = @PremiumAmount WHERE PolicyId = @PolicyId";

                using (var command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
                    command.Parameters.AddWithValue("@PolicyDetails", policy.PolicyDetails);
                    command.Parameters.AddWithValue("@PremiumAmount", policy.PremiumAmount);
                    command.Parameters.AddWithValue("@PolicyId", policy.PolicyId);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }


        public bool DeletePolicy(int policyId)
        {
            try
            {
                using (var connection = DBConnection.getConnection())
                {
                    string query = "DELETE FROM Policies WHERE PolicyId = @PolicyId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PolicyId", policyId);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0; 
                    }
                }
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
                using (var connection = DBConnection.getConnection())
                {
                    string query = "SELECT * FROM Users WHERE username = @Username AND password = @Password";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("login failed");
                return false;
            }
        }
    }
}