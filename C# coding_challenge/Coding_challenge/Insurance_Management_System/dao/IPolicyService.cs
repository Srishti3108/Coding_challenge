using System.Collections.Generic;
using Insurance_Management_System.Entity;

namespace Insurance_Management_System.dao
{
    internal interface IPolicyService
    {

        bool CreatePolicy(Policy policy);


        Policy GetPolicy(int policyId);


        List<Policy> GetAllPolicies();


        bool UpdatePolicy(Policy policy);


        bool DeletePolicy(int policyId);

        bool login(string username, string password);
    }
}

