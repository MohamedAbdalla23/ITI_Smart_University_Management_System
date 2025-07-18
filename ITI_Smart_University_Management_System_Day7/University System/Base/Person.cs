namespace ITI_Smart_University_Management_System_Day7.University_System.Base
{
    internal abstract class Person
    {
        private string? name;               
        private string? email;
        private string? phone;

        public string Name
        {
            get { return name!; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "Name cannot be null.");
                }
                name = value;
            }
        }
        public string Email
        {
            get { return email!; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Email), "Name cannot be null."); ;
                }
                email = value;
            }
        }
        public string Phone
        {
            get { return phone!; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Phone), "Name cannot be null."); ;
                }
                phone = value;
            }
        }

        public Address Address { get; set; }

        protected Person()
        {

        }

        protected Person(string name, string email, string phone, Address address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public abstract void DisplayProfile();

    }
}
