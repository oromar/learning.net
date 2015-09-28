using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RazorMVCExample.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(6, MinimumLength=3)]
        [Display(Name= "User Name")]
        [RegularExpression(@"(\S)+", ErrorMessage="White space is not allowed")]
        [ScaffoldColumn(false)]
        public string UserName { get; set; }
        [Required]
        [StringLength(8, MinimumLength=3)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(9, MinimumLength=3)]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
    }

    public class Users
    {
        public Users()
        {
            _userList.Add(new UserModel
            {
               UserName = "BenM",
               FirstName = "Ben",
               LastName = "Miller",
               City = "Seattle"
            });

            _userList.Add(new UserModel
            {
               UserName = "AnnB",
               FirstName = "Ann",
               LastName = "Beebe",
               City = "Boston"
            });

        }

        public List<UserModel> _userList = new List<UserModel>();

        public void Update(UserModel model)
        {
            UserModel u = GetUser(model.UserName);
            if (u != null)
            {
                _userList.Remove(u);
                _userList.Add(model);
            }   
            else 
            {
                throw new System.InvalidOperationException("UserName: " + model.UserName + " Not Found");
            }
        }

        public void Create(UserModel model)
        {
            var u = GetUser(model.UserName);
            if (u == null)
            {
                _userList.Add(model);
            } 
            else 
            {
                throw new System.InvalidOperationException("UserName: " + model.UserName + " already exists ");
            }            
        }

        public void Remove(string userName)
        {
            var u = GetUser(userName);
            if (u != null)
            {
                _userList.Remove(u);
            }
            else 
            {
                throw new System.InvalidOperationException("UserName: " + userName + " Not Found");
            }
        }

        public UserModel GetUser(string userName)
        {
            foreach(var u in _userList)
            {
                if (u.UserName == userName)
                {
                    return u;
                }                    
            }
            return null;
        }

    }

}