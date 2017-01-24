using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace yad2.Control
{
    public class Controller
    {
        Model.Model m_model;
        MainWindow m_v;
        public Controller(Model.Model m, MainWindow v)
        {
            m_model = m;
            m_v = v;
        }
        
        internal List<string> getGroupList(string email)
        {
            return m_model.getGroupList(email);
        }

        internal List<string> GroupMembers(string groupID)
        {
            return m_model.GroupMembers(groupID);
        }





        internal string GroupManager(string groupID)
        {
            return m_model.GroupManager(groupID);
        }



        internal string GroupCategory(string groupID)
        {
            return m_model.GroupCategory(groupID);
        }



        internal System.Collections.IEnumerable getALLCategories()
        {
            return m_model.getALLCategories();
        }

        internal System.Collections.IEnumerable getALLLocations()
        {
            return m_model.getALLLocations();
        }

        internal List<Add> getSearchAds(string cat, string loc)
        {
            return m_model.getSearchAds(cat, loc);
        }

        internal bool UserExist(string p)
        {
            return m_model.UserExists(p);
        }

        internal User getUsers(string p)
        {
            return m_model.getUser(p);
        }

        internal void addNewUser(string mail, string password, string firstname, string lastname, int age, bool isMale)
        {
            m_model.addNewUser(mail,password,firstname,lastname,age,isMale);
        }


        internal bool isPublished(int id)
        {
            return m_model.AddisPublished(id);
        }

        internal void RemoveAd(int m_groupID)
        {
            m_model.RemoveAd(m_groupID);
        }

        internal void AddNewAd(DateTime eventDate, string about, DateTime publishedDate, string loc, string cat, string m_userEmail, int m_groupid)
        {
            m_model.AddNewAd( eventDate,  about,  publishedDate,  loc,  cat,  m_userEmail,  m_groupid);
                
        }

        internal void AddNewGroup(string cat,string email,List <string> partners)
        {
            m_model.AddNewGroup(cat,email,partners);
            
        }

        internal void AddNewCategory(string cat)
        {
            m_model.AddNewCategory(cat);
        }

        internal string AdLocation(int AdID)
        {
            return m_model.Adlocation(AdID);
        }

        internal string AdAbout(int AdID)
        {
            return m_model.AdAbout(AdID);
        }

        internal void AddNewRequest(int m_AdID, string m_userMail)
        {
            m_model.AddNewRequest(m_AdID, m_userMail);
        }
        internal List<string> GetChat(string GroupID)
        {
            return m_model.GetChat(GroupID);
        }
        internal bool IscategoryExsist(string cat)
        {
            return m_model.isCategoryexsit(cat);
        }




        internal List<string> addMessageToChat(string m_GroupID, string m_email, string m_text)
        {
            return m_model.addMessageToChat(m_GroupID, m_email, m_text);
        }
        internal string[] GetDetails(string email)
        {
            return m_model.GetDetails(email);
        }
    }
}
