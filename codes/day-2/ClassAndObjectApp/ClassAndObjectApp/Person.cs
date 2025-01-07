namespace ClassAndObjectApp
{
    class Person
    {
        int id;
        string name;
        long mobile;

        //no return type
        //name of this method is same as that of the class
        //it can accpet arguments (parameterozed ctor) or might not accept any arguments (default/parameterless ctor)

        //default ctor
        public Person()
        {
            //id = 0;
            //name = null;
            //mobile = 0;
        }

        //parameterized ctor
        public Person(int pId, string pName, long pMobile)
        {
            id = pId;
            name = pName;
            mobile = pMobile;
        }
    }
}
