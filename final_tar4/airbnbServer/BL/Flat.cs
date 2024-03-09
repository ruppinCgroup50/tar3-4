namespace tar2.BL
{
    public class Flat
    {
        int id;
        string city;
        string address;
        double price;
        int numberofroom;
        static List<Flat> FlatsList = new List<Flat>();

        public Flat()
        {
        }

        public Flat(int id, string city, string address, double price, int numberofroom)
        {
            Id = id;
            City = city;
            Address = address;
            Numberofroom = numberofroom;
            Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public int Numberofroom { get => numberofroom; set => numberofroom = value; }
        public double Price { get => price; 
            set 
            {
                price = value;
                price = Discount();  
            } 
        }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertFlat(this);
        }

        public List<Flat> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadFlats();
        }

        public int Delete(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteFlat(id);
        }

        //public bool Insert()
        //{
        //    for (int i = 0; i < FlatsList.Count; i++)
        //    {
        //        if (FlatsList[i].Id == this.Id)
        //        {
        //            return false;
        //        }
        //    }
        //    FlatsList.Add(this);
        //    return true;
        //}

        //public List<Flat> Read()
        //{
        //    return FlatsList;
        //}

        public double Discount()
        {
            double discountedPrice = this.Price;
            if (this.Numberofroom > 1 && this.Price > 100)
            {
                discountedPrice *= 0.9;
            }
            return discountedPrice;
        }

        //public List<Flat> ReadByCityAndPrice(string city, double price)
        //{
        //    List<Flat> selectedList = new List<Flat>();
        //    foreach (Flat f in FlatsList)
        //    {
        //        if (f.City == city && f.Price < price)
        //            selectedList.Add(f);
        //    }
        //    return selectedList;
        //}
    }
}
