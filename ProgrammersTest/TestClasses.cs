using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProgrammersTest
{
    public class StorageClass
    {
        
        public string Id { get; set; }
        public void Save()
        {
            this.Id = Guid.NewGuid().ToString();
            try
            {
                using (StreamWriter writer = File.AppendText("storage.json"))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(this));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Object Find(string id)
        {
            using (StreamReader reader = new StreamReader("storage.json"))
            {
                string line;
                //var classType = this.GetType();
                while ((line = reader.ReadLine()) != null)
                {
                    dynamic serializedData = JsonConvert.DeserializeObject(line);
                    if (serializedData["Id"] == id)
                    {
                        //if (this)
                        Customer result = new Customer(line);
                        //Customer result;
                        //result.Id = line["Id"];
                        //return result;
                        return result;
                    }
                }
            }
            return null;
        }
        public void Delete()
        {

        }
    }

    public class Customer : DataType
    {
        public Customer(string first, string last, Address address)
        {
            FirstName = first;
            LastName = last;
            Address = address;
        }

        public Customer(string line)
        {
            dynamic deserialized = JsonConvert.DeserializeObject(line);
            this.FirstName = deserialized["firstName"];
            this.LastName = deserialized["lastName"];
            this.Address = new Address();
            this.Address.AddressLineOne = deserialized["address"];
            this.Address.City = deserialized["city"];
            this.Address.State = deserialized["state"];
            this.Address.ZipCode = deserialized["zip"];
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }

    public class Company : DataType
    {
        public Company(string name, Address address)
        {
            Name = name;
            Address = address;
        }
        public string Name { get; private set; }
        public Address Address { get; private set; }
    }

    public class Address
    {
        public Address(string addressLineOne, string city, string state, string zip)
        {
            AddressLineOne = addressLineOne;
            City = city;
            State = state;
            ZipCode = zip;
        }

        public Address()
        {

        }
        public string AddressLineOne { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public abstract class DataType : StorageClass
    {

    }
}
