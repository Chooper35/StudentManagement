using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManagementDAL.Data;
using StudentManagementMODELS.Models;

namespace StudentManagementBUS.StudentDal
{
    public class StudentService
    {
        private readonly StudentDBContext _context;

        public StudentService(StudentDBContext context)
        {
            _context = context;
        }
        //--------GET METHODS----------
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
        public Student GetStudentById(int studentID)
        {
            return _context.Students.FirstOrDefault(p => p.Id == studentID);
        }

        //need Class Model implementation and Call
        //public List<Student> GetStudentsByClassId(int classID)
        //{
        //    return _context.Students.ToList().Where(p => p.classID == classID).ToList();
        //}
        
        //--------POST METHODS----------
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public bool DeleteStudent(int studentID) 
        {
            var errorMessage = "";
            try
            {
                var student = _context.Students.Find(studentID);
                if (student == null)
                {
                    return false;
                }
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                //log the error or pass the error message to controller
                //todo: you can return object that includes error message and boolean value
                return false;
            }        
        }

        public void AddStudentsBulk(List<Student> students)
        {
            try
            {
                _context.BulkInsert(students);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during bulk insert: {ex.Message}");
            }
        }

    }
}
