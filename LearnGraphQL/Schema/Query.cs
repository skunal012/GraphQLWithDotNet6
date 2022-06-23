using System.Collections.Generic;

namespace LearnGraphQL.Schema
{
    public class Query
    {
        public IEnumerable<CourseType> GetCourses()
        {
            return new List<CourseType>()
            {
                new CourseType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Geometry",
                    Subject = Subject.Science,
                    Instructor = new InstructorType()
                    {
                        Id= Guid.NewGuid(),
                        FirstName= "Kunal",
                        LastName= "singh",
                        Salary= 430000,
                    },
                    Students = new List<StudentType>()
                    {
                        new StudentType()
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Suriya",
                            LastName= "Singh",
                            GPA = 8,
                        }
                    }
                }
            };
        }

        [GraphQLDeprecated("This query is Deprecated.")]
        public string test => "Hello world, learnt .net core 6 with Graphql";
    }
}
