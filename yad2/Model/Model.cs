using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yad2.Control;


namespace yad2.Model
{
    public class Model
    {
        Controller m_controller;
        Yad2Entities _db;
        int m_counter;
        public void SetController(Controller c)
        {
            m_controller = c;
            _db = new Yad2Entities();
            m_counter = _db.Groups.Count()+1;
        }

        internal List<string> getGroupList(string email)
        {
            List<Group> g = null;

            List<User> l_g = _db.Users.Where(x => x.Email == email).ToList();
            List<string> l_g_text = new List<string>();
            if (l_g[0] is Partner)
            {
                g = (((Partner)l_g[0]).PartnerIn).ToList();
                foreach (Group gp in g)
                {
                    l_g_text.Add(gp.Id + " , " + gp.CategoryType);
                }
            }
            return l_g_text;
        }


        internal string GroupCategory(string groupID)
        {
            int groupId = Convert.ToInt32(groupID);

            return _db.Groups.Where(x => x.Id == groupId).ToList()[0].CategoryType;
        }



        internal string GroupManager(string groupID)
        {
            int groupId = Convert.ToInt32(groupID);
            return _db.Groups.Where(x => x.Id == groupId).ToList()[0].Manager.FirstName + " " + _db.Groups.Where(x => x.Id == groupId).ToList()[0].Manager.LastName;
        }

        internal List<string> GroupMembers(string groupID)
        {
            int groupId = Convert.ToInt32(groupID);

            List<Group> l_g = _db.Groups.Where(x => x.Id == groupId).ToList();
            List<string> l_g_text = new List<string>();

            foreach (Partner gp in l_g[0].Partners)
            {
                if (l_g[0].Manager.Email != gp.Email)
                {
                    l_g_text.Add(gp.FirstName + " " + gp.LastName);

                }
            }

            return l_g_text;
        }

        internal System.Collections.IEnumerable getALLCategories()
        {
            List<string> cat = new List<string>();
            var items = (from u in _db.Categories select new { u.Type });
            foreach (var u in items)
                cat.Add(u.Type);
            return cat;
        }

        internal System.Collections.IEnumerable getALLLocations()
        {
            List<string> loc = new List<string>();
            var items1 = (from u in _db.Locations select new { u.Area });
            foreach (var u in items1)
                loc.Add(u.Area);
            return loc;
        }

        internal List<Add> getSearchAds(string cat, string loc)
        {
            List<Add> adds = _db.Adds.Where(x => x.LocationArea == loc && x.CategoryType == cat).ToList();
            return adds;
        }

        internal bool UserExists(string p)
        {
            var users = (from u in _db.Users
                         where u.Email == p
                         select new
                         {
                             u.Password,
                             u.FirstName,
                             u.LastName
                         });
            return users.Count() > 0;
        }

        internal User getUser(string p)
        {
            return _db.Users.Where(x => x.Email == p).FirstOrDefault();
        }

        internal void addNewUser(string email, string password, string firstname, string lastname, int age, bool isMale)
        {
            User newUser = new User();
            newUser.Email = email;
            newUser.Password = password;
            newUser.FirstName = firstname;
            newUser.LastName = lastname;
            newUser.Age = age;
            newUser.Gender = isMale;
            _db.Users.Add(newUser);
            _db.SaveChanges();
        }

        internal bool AddisPublished(int id)
        {
            var adds = _db.Adds.Where(x => x.id == id).ToList();
            return adds.Count() > 0;
        }

        internal void RemoveAd(int m_groupID)
        {
            Add ad = _db.Adds.Where(x => x.id == m_groupID).FirstOrDefault();
            _db.Adds.Remove(ad);
            _db.SaveChanges();
        }


        internal void AddNewAd(DateTime eventDate, string about, DateTime publishedDate, string loc, string cat, string m_userEmail, int groupid)
        {
            Add newAd = new Add();
            newAd.EventDate = eventDate;
            newAd.About = about;
            newAd.DatePublished = publishedDate;
            newAd.Category = _db.Categories.Where(x => x.Type == cat).FirstOrDefault();
            newAd.LocationArea = loc;
            newAd.Location = _db.Locations.Where(x => x.Area == loc).FirstOrDefault();
            newAd.CategoryType = cat;
            newAd.PartnerEmail = m_userEmail;
            newAd.Advertisor = (Partner)_db.Users.Where(x => x.Email == m_userEmail).FirstOrDefault();
            newAd.Group = _db.Groups.Where(x=>x.Id==groupid).FirstOrDefault();
            newAd.id = groupid;
            _db.Adds.Add(newAd);
            _db.SaveChanges();
        }


        internal void AddNewGroup(string cat, string email, List<string> partners)
        {
            Group newGroup = new Group();
            newGroup.CategoryType = cat;
            newGroup.Category = _db.Categories.Where(X => X.Type == cat).FirstOrDefault();
            User user = _db.Users.Where(x => x.Email == email).FirstOrDefault();
            Manager maneger;
            if (user is Manager)
                maneger = (Manager)user;
            else
            {
                //if not maneger make new user as menager
                maneger = new Manager();
                maneger.Email = email;
                maneger.Age = user.Age;
                maneger.FirstName = user.FirstName;
                maneger.Gender = user.Gender;
                maneger.LastName = user.LastName;
                maneger.Password = user.Password;
                if (user is Partner)
                {
                    Partner p = (Partner)user;
                    //maneger.AddsAdvertized = p.AddsAdvertized;
                    foreach (Add item in p.AddsAdvertized)
                    {
                        item.Advertisor = maneger;
                        maneger.AddsAdvertized.Add(item);
                    }
                   // maneger.PartnerIn = p.PartnerIn;
                    foreach (Group item in p.PartnerIn)
                    {
                        item.Partners.Remove(p);
                        item.Partners.Add(maneger);
                        maneger.PartnerIn.Add(item);
                    }
                }
                _db.Users.Remove(user);
                _db.Users.Add(maneger);
            }
            List<Partner> groupMembers = new List<Partner>();
            foreach (string p in partners)
            {
                user = _db.Users.Where(x => x.Email == p).FirstOrDefault();
                Partner partner;
                if (user is Partner)
                    partner = (Partner)user;
                else
                {
                    //if not partner make new user as partner
                    partner = new Partner();
                    partner.Email = user.Email;
                    partner.Age = user.Age;
                    partner.FirstName = user.FirstName;
                    partner.Gender = user.Gender;
                    partner.LastName = user.LastName;
                    partner.Password = user.Password;
                    _db.Users.Remove(user);
                    _db.Users.Add(partner);
                }
                newGroup.Partners.Add(partner);
                groupMembers.Add(partner);
                
            }


            newGroup.Manager = maneger;
            newGroup.Id = m_counter;
            m_counter++;
            newGroup.ManagerEmail = email;
            newGroup.Partners.Add(maneger);
            newGroup.Chat = null;
            _db.Groups.Add(newGroup);
            //add the group to manager lists
            maneger.Groups.Add(newGroup);
            maneger.PartnerIn.Add(newGroup);
            
            foreach (Partner p in groupMembers)
            {
                p.PartnerIn.Add(newGroup);
            }
            _db.SaveChanges();
        }

        internal void AddNewCategory(string cat)
        {
            
                Category newcateg = new Category();
                newcateg.Type = cat;
                _db.Categories.Add(newcateg);
                _db.SaveChanges();
        }
        public bool isCategoryexsit(string cat)
        {
            return _db.Categories.Where(x => x.Type == cat).Count() != 0;
        }

        internal string  Adlocation(int AdID)
        {
            Add ad = _db.Adds.Where(x => x.id == AdID).FirstOrDefault();
            return ad.Location.Area;
        }

        internal string AdAbout(int AdID)
        {
            Add ad = _db.Adds.Where(x => x.id == AdID).FirstOrDefault();
            return ad.About;
        }

        internal void AddNewRequest(int m_AdID, string m_userMail)
        {
            Group g = _db.Groups.Where(x => x.Id == m_AdID).FirstOrDefault();
            User u = _db.Users.Where(x => x.Email == m_userMail).FirstOrDefault();
            foreach (Partner par in g.Partners)
            {
                Request r = new Request();
                r.Add = _db.Adds.Where(x => x.id == m_AdID).FirstOrDefault();
                r.Partner = par;
                r.status = false;
                r.User = u;
                par.RequestsRecived.Add(r);
                u.RequestsSent.Add(r);

            }
            
        }
        internal List<string> GetChat(string GroupID)
        {
            int g_id = Int32.Parse(GroupID);
            Group g = _db.Groups.Where(x => x.Id == g_id).FirstOrDefault();
            string chatAsString = g.Chat;
            if (chatAsString != null)
            {
                string[] chatAsArr = chatAsString.Split('\n');
                return chatAsArr.ToList();
            }
            return null;

        }

        internal List<string> addMessageToChat(string m_GroupID, string m_email, string m_text)
        {
            int g_id = Int32.Parse(m_GroupID);
            Group g = _db.Groups.Where(x => x.Id == g_id).FirstOrDefault();
            g.Chat += m_email + ": " + m_text + '\n';
            _db.SaveChanges();
            string chatAsString = g.Chat;
            string[] chatAsArr = chatAsString.Split('\n');
            return chatAsArr.ToList();

        }

        internal string[] GetDetails(string email)
        {
            User user = _db.Users.Where(x => x.Email == email).FirstOrDefault();
            string[] ans = new string[4];
            ans[0] = user.FirstName + " " + user.LastName;
            ans[1] = "Email: " + user.Email;
            if (user.Gender == true)
                ans[2] = "Gender: Female";
            else
                ans[2] = "Gender: Male";
            ans[3] = "Age: " + user.Age.ToString();

            return ans;


        }
    }
}
