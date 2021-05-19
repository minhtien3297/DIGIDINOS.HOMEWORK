using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Repositories
{
    public class Comments : IComments
    {

        public void InsertComment(Comment Comment)

        {

            using (DbconnectionContext context = new DbconnectionContext())

            {

                context.Comment.Add(Comment);

                context.SaveChanges();

            }

        }

        public IEnumerable<Comment> ListofComment()

        {

            using (DbconnectionContext context = new DbconnectionContext())

            {

                var listofcomments = from comments in context.Comment

                                     select comments;

                return listofcomments;

            }

        }

    }
}
