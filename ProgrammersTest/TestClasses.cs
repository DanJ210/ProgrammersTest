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
        public void Save<T>(T classToSave) where T : class
        {
            StreamWriter writer = File.CreateText("storage.json");
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, classToSave);
        }
    }

    public class Customer
    {
        public Customer(string first, string last, Address address)
        {
            FirstName = first;
            LastName = last;
            Address = address;
            //Id = new Guid().ToString();
            var testing = JsonConvert.SerializeObject(this);
        }
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }

        public void Save()
        {
            StreamWriter writer = File.CreateText("storage.json");
            //JsonSerializer serializer = new JsonSerializer();
            //serializer.Serialize(writer, this);
            var testing = JsonConvert.SerializeObject(this);
            //JsonConvert.SerializeObject(this);
        }
        public void Delete()
        {

        }

        public static Customer Find(string id)
        {
            throw new NotImplementedException();
        }
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
        public string AddressLineOne { private get; set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
    }

    public class Company
    {
        public Company(string name, Address address)
        {
            Name = name;
            Address = address;
            //Id = new Guid().ToString();
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; private set; }

        public void Save()
        {
            
        }

        public void Delete()
        {

        }

        public static Company Find(string id) {
            throw new NotImplementedException();
        }
    }
}
