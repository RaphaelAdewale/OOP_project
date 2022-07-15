using System;

namespace OOPTutorialProject
{
    class Person
    {
        //private fields
        private string _firstname = "";
        private string _lastname = "";
        private string _occupation = "";
        private int _age = 0;

        // public fields
        public string FirstName{ get {return _firstname; } }
        public string LastName{ get {return _lastname; } }
        public string Occupation{ get {return _occupation; } }
        public int Age{ get {return _age; } }

        // constructor    
        public Person(string firstname, string lastname, string occupation, int age)
        {
            _firstname = firstname;
            _lastname = lastname;
            _occupation = occupation;
            _age = age;
        }
    }
}