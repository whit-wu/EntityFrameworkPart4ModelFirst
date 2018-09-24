using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPart6ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TenForwardEntities ctx = new TenForwardEntities())
            {
                Customers customer = new Customers { CustomerID = 1, CustomerName = "Data" };
                Transactions transaction1 = new Transactions { TransactionID = 1, TransactionAmount = "40.00", CustomersCustomerID = 1 };
                Transactions transaction2 = new Transactions { TransactionID = 2, TransactionAmount = "30.00", CustomersCustomerID = 1 };

                ctx.Customers.Add(customer);
                ctx.Transactions.Add(transaction1);
                ctx.Transactions.Add(transaction2);

                ctx.SaveChanges();

                var query = from c in ctx.Customers
                            join t in ctx.Transactions
                            on c.CustomerID equals t.CustomersCustomerID
                            select new
                            {
                                c.CustomerName,
                                t.TransactionAmount, 
                                t.TransactionID
                            };


                foreach(var q in query)
                {
                    Console.WriteLine(q.CustomerName.ToString() + " owes  " + q.TransactionAmount + " for transaction " + q.TransactionID.ToString());
                }
                
            }
        }
    }
}
