using HotChocolate.Subscriptions;
using LearnGraphQL.Schema.Subscriptions;

namespace LearnGraphQL.Schema.Mutations
{
    public class Mutation
    {
        public readonly List<CourseResult> _courseResults;

        public Mutation()
        {
            _courseResults = new List<CourseResult>();
        }

        // Create Course
        public async Task<CourseResult> CreateCourse(CourseTypeInput courseTypeInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult course = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseTypeInput.Name,
                Subject = courseTypeInput.Subject,
                InstructorId = courseTypeInput.InstructorId,
            };
            _courseResults.Add(course);
            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);

            return course;            
        }

        // update the course
        public CourseResult UpdateCourse(Guid id, CourseTypeInput courseTypeInput)
        {
            CourseResult course = _courseResults.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new GraphQLException(new Error("Course not found", "COURSE_NOT_FOUND"));
            }

            course.Name = courseTypeInput.Name;
            course.Subject = courseTypeInput.Subject;
            course.InstructorId = courseTypeInput.InstructorId;
            return course;
        }

        // delete the course
        public bool DeleteCourse(Guid id)
        {
            return _courseResults.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
