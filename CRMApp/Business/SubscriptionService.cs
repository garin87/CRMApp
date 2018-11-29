using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CRMApp.Model;

namespace CRMApp.Business
{
    class SubscriptionService : EntityProvider<Subscription>
    {
        private const string INSERT_COMMAND =
            @"INSERT INTO Subscription(Name, Price, Amount) 
            VALUES(@Name, @Price, @Amount)";
        private const string UPDATE_COMMAND =
            @"UPDATE Subscription SET Name=@Name, Price=@Price, 
                Amount=@Amount
            WHERE SubscriptionID=@SubscriptionID";

        public override void Save(Subscription entity)
        {
            SqlCommand command = new SqlCommand("", _connection);

            if (entity.SubscriptionID == null)
            {
                command.CommandText = INSERT_COMMAND;
            }
            else
            {
                command.CommandText = UPDATE_COMMAND;
                command.Parameters.AddWithValue("@SubscriptionID", entity.SubscriptionID);
            }

            command.Parameters.AddWithValue("@Name", entity.Name ?? "");
            command.Parameters.AddWithValue("@Price", entity.Price ?? "");
            command.Parameters.AddWithValue("@Amount", entity.Amount ?? "");

            command.ExecuteNonQuery();
        }


        protected override Subscription Load(DataRow row)
        {
            Subscription entity = new Subscription();

            if (!(row["SubscriptionID"] is DBNull))
                entity.SubscriptionID = Convert.ToInt32(row["SubscriptionID"]);
            if (!(row["Amount"] is DBNull))
                entity.Amount = Convert.ToString(row["Amount"]);
            if (!(row["Price"] is DBNull))
                entity.Price = Convert.ToString(row["Price"]);
            if (!(row["Name"] is DBNull))
                entity.Name = Convert.ToString(row["Name"]);
            return entity;
        }
    }
}
