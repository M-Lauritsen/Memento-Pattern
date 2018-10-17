using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_Pattern
{
    class Program
    {
        class FoodSupplier
        {
            private string _name;
            private string _phone;
            private string _address;

            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    Console.WriteLine("Propriertor: " + _name);
                }
            }

            public string Phone
            {
                get { return _phone; }
                set
                {
                    _phone = value;
                    Console.WriteLine("Address: " + _address);
                }
            }

            public string Address
            {
                get { return _address; }
                set
                {
                    _address = value;
                    Console.WriteLine("Address: " + _address);
                }
            }

            public FoodSupplierMemento SaveMemento()
            {
                Console.WriteLine("\nSaving current state\n");
                return new FoodSupplierMemento(_name, _phone, _address);
            }

            public void RestoreMemento(FoodSupplierMemento memento)
            {
                Console.WriteLine("\nRestoring previous state\n");
                Name = memento.Name;
                Phone = memento.PhoneNumber;
                Address = memento.Address;
            }
        }

        class FoodSupplierMemento
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }

            public FoodSupplierMemento(string name, string phone, string address)
            {
                Name = name;
                PhoneNumber = phone;
                Address = address;
            }
        }

        class SupplierMemory
        {
            public FoodSupplierMemento Memento { set; get; }

        }
        static void Main(string[] args)
        {
            //var memento = someWriter.CreateMemento();
            //someWriter.startWriting();

            FoodSupplier s = new FoodSupplier();
            s.Name = "Harold Karstark";
            s.Phone = "(482) 555-1172";
            // Let's store that entry in our database.
            SupplierMemory m = new SupplierMemory();
            m.Memento = s.SaveMemento();
            // Continue changing originator
            s.Address = "548 S Main St. Nowhere, KS";
            // Crap, gotta undo that entry, I entered the wrong address
            s.RestoreMemento(m.Memento);
            Console.ReadKey();
        }
    }
}
