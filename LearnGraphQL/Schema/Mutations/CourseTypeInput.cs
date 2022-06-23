﻿namespace LearnGraphQL.Schema.Mutations
{
    public class CourseTypeInput
    {
        public string Name { get; set; } 
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
