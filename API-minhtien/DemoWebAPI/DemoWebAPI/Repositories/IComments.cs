using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Repositories
{
    interface IComments
    {
        void InsertComment(Comment Comment); //Inserting

        IEnumerable<Comment> ListofComment(); //List of Comment
    }
}