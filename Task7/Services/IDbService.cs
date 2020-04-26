using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task7.Models;

namespace Task7.Services
{
    public interface IDbService
    {
        Student GetStudent(string password);
    }
}
