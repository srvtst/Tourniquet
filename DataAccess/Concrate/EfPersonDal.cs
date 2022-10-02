﻿using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate
{
    public class EfPersonDal : IPersonDal
    {
        public List<Person> GetAll()
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Person>().ToList();
            }
        }

        public void Add(Person person)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var added = context.Add(person);
                context.SaveChanges();
            }
        }

        public void Update(Person person)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var updated = context.Update(person);
                context.SaveChanges();
            }
        }

        public void Delete(Person person)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                var deleted = context.Remove(person);
                context.SaveChanges();
            }
        }

        public Person GetByPerson(int personId)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Person>().SingleOrDefault(p => p.Id == personId);
            }
        }
        public Person GetByEmail(string email)
        {
            using (TourniquetContext context = new TourniquetContext())
            {
                return context.Set<Person>().SingleOrDefault(x => x.Email == email);
            }
        }
    }
}