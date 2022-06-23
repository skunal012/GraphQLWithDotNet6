using LearnGraphQL.Schema.Mutations;

namespace LearnGraphQL.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;
    }
}
