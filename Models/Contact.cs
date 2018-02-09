using System.Collections.Generic;
using System;
namespace Addressbook.Models
{
    public class Contact
    {
        private string _name;
        private string _number;
        private string _email;
        private string _address;
        private int _id;
        private static List<Contact> _allContacts = new List<Contact>{};

        public Contact(string nameIn, string numberIn, string emailIn, string addressIn)
        {
            _name = nameIn;
            _number = numberIn;
            _email = emailIn;
            _address = addressIn;
            _id = _allContacts.Count + 1;
        }
        //GETTERS
        public string GetName()
        {
            return _name;
        }
        public string GetNumber()
        {
            return _number;
        }
        public string GetEmail()
        {
            return _email;
        }
        public string GetAddress()
        {
            return _address;
        }
        public int GetId()
        {
            return _id;
        }
        //SETTERS
        public void SetName(string nameIn)
        {
            _name = nameIn;
        }
        public void SetNumber(string numberIn)
        {
            _number = numberIn;
        }
        public void SetEmail(string emailIn)
        {
            _email = emailIn;
        }
        public void SetAddress(string addressIn)
        {
            _address = addressIn;
        }
        //List Methods
        public static List<Contact> GetAll()
        {
            return _allContacts;
        }
        public static void ClearAll()
        {
            _allContacts.Clear();
        }
        public void PushToList()
        {
            if(!checkContact(this)){
                _allContacts.Add(this);
            }

        }
        //Return false if inputContact is not in the list. Return true if inputContact is already in the list.
        public static bool checkContact(Contact inputContact)
        {
            if(_allContacts.Count == 0)
            {
                return false;
            }
            else
            {
                //Going through each element in the allContacts list
                foreach(Contact index in _allContacts)
                {
                    //If all properties of inputContact exist anywhere in the list. Return true.
                    if(index.GetName() == inputContact.GetName() && index.GetNumber() == inputContact.GetNumber() && index.GetEmail() == inputContact.GetNumber() && index.GetAddress() == inputContact.GetAddress())
                    {
                        return true;
                    }
                    else
                    {
                    }
                }
            }
            //If got through entire list and no return happened. Contact must not be in the list.
            return false;
        }
        //ID Methods
        public static Contact Find(int searchId)
        {
            return _allContacts[searchId-1];
        }
    }
}
