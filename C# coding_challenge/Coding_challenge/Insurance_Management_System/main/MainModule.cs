using Insurance_Management_System.dao;
using Insurance_Management_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Insurance_Management_System.main
{
    internal class MainModule
    {
        public static void Main(String[] args)
        {
            IPolicyService service = new InsuranceServiceImpl();
            Policy policy = null;
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            if (service.login(username, password))
            {
                while (true)
                {
                    bool logout = false;
                    Console.Write("Enter 1 to create policy");
                    Console.Write("Enter 2 to Get policy");
                    Console.Write("Enter 3 to list all the policies");
                    Console.Write("Enter 4 to update a policy");
                    Console.Write("Enter 5 to delete a policy");
                    Console.Write("Enter 6 to logout");
                    Console.Write("Enter 7 to Exit");
                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid choice. Please enter a number.");
                        continue;
                    }
                    switch (choice)
                    {
                        case 1:
                            policy = new Policy();

                            Console.WriteLine("Enter The Id of the Policy to create:");
                            policy.PolicyId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the Name of the Policy:");
                            policy.PolicyName = Console.ReadLine();

                            Console.WriteLine("Enter the Amount of Policy:");
                            policy.PremiumAmount = double.Parse(Console.ReadLine());

                            if (service.CreatePolicy(policy))
                                Console.WriteLine("Policy created successfully");
                            break;
                        case 2:
                            int policyId;

                            Console.WriteLine("Enter the ID of the Policy which you want to view");
                            policyId = int.Parse(Console.ReadLine());
                            policy = service.GetPolicy(policyId);
                            Console.WriteLine(policy.ToString());
                            break;
                        case 3:
                            List<Policy> policyList = service.GetAllPolicies();
                            foreach(Policy p in  policyList)
                            {
                                Console.WriteLine(p.ToString());
                            }
                            break;
                        case 4:
                            //service.UpdatePolicy();
                            break;
                        case 5:
                            int policyID;

                            Console.WriteLine("Enter the ID of the Policy which you want to view");
                            policyID = int.Parse(Console.ReadLine());
                            if (service.DeletePolicy(policyID))
                                Console.WriteLine("Deleted successfully");
                            break;
                        case 6:
                            logout = true;
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                    if (logout)
                        break;
                }

            }
            else
            {
                Console.WriteLine("Login Failed");
            }
        }
    }
}
