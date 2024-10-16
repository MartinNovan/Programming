using System.Dynamic;

namespace Prace_v_hodine
{
    internal class Program
    {   
        //přístupové identifikátory
        //vlastnosti
        
        static void Main(string[] args)
        {
            Person person = new Person();
            person.LastName = "TEST"; //zde tato metoda nefunguje
            person.ID = 1; // funguje všude
            person.FirstName = "TEST"; //nefunguje jelikož nedědí
            person.GetStudentID();
        }
    }

    class Student : Person 
    { 
        public void Method()
        {
            FirstName = "TEST"; //funguje jelikož dědí
            ID = 2; //funguje všude
        }

        private int StudentID;

        public int GetStudentID() 
        {
            return StudentID;
        }

        public int PersonID { get; private set; } //metodu si mohu propůjčit kdekoliv ale nastavit ho můžu pouze privátně ()
    }

    class Person
    {
        public int ID; //toto vidí všichni a můžu ji použít všude
        private string LastName; //privátní metody fungují pouze zde
        protected string FirstName; //toto vidí pouze ti co dědí 

        public void SomeMethod()
        {
            LastName = "TEST"; //funguje jelikož je to ve stejné třídě
        }
    }
}
