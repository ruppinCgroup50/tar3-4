using System;

namespace tar2.BL
{
    public class Vacation
    {
        int id;
        string userId;
        int flatId;
        DateTime startDate;
        DateTime endDate;
        static List<Vacation> vacationList = new List<Vacation>();

        public Vacation()
        {
        }

        public Vacation(int id, string userId, int flatId, DateTime startDate, DateTime endDate)
        {
            Id = id;
            UserId = userId;
            FlatId = flatId;
            StartDate = startDate.Date;
            EndDate = endDate.Date;
        }

        public int Id { get => id; set => id = value; }
        public string UserId { get => userId; set => userId = value; }
        public int FlatId { get => flatId; set => flatId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public List<Vacation> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadVacations();
        }

        public List<Vacation> ReadByUserEmail(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.GetVacationByEmail(email);
        }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            List<Vacation> vacationList = Read();

            foreach (var v in vacationList)
            {
                if (this.flatId == v.flatId)
                {
                    if (this.startDate > v.endDate || this.endDate < v.startDate)
                    {
                        continue;
                    }
                    return 0;
                }
            }
            return dbs.InsertVacation(this);
        }

        public int Delete(int id)
        {
            DBservices dbs = new DBservices();
            return dbs.DeleteVacation(id);
        }

        //public bool Insert()
        //{
        //    foreach (Vacation vacation in vacationList) {
        //    if(this.Id == vacation.Id || this.FlatId == vacation.FlatId && this.StartDate <= vacation.EndDate && this.EndDate >= vacation.StartDate)
        //        {
        //            return false;
        //        }
        //    }
        //    vacationList.Add(this);
        //    return true;
        //}

        //public List<Vacation> Read()
        //{
        //    return vacationList;
        //}

        //public List<Vacation> ReadByDates(DateTime startDat, DateTime endDate)
        //{
        //    List<Vacation> selectedList = new List<Vacation>();
        //    foreach (Vacation v in vacationList)
        //    {
        //        if (v.StartDate >= startDat && v.EndDate <= endDate)
        //            selectedList.Add(v);
        //    }
        //    return selectedList;
        //}
    }
}
