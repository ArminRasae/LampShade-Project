using System.Collections;
using Execution;

List<Course> courses = new()
{
    new Course() { Id = 1, Name = "c-sharp", Price = 10000 },
    new Course() { Id = 2, Name = "Asp NET Core", Price = 20000 },
    new Course() { Id = 2, Name = "css", Price = 5000 },
    new Course() { Id = 2, Name = "css", Price = 7000 },
    new Course() { Id = 5, Name = "MongoDb", Price = 55000 },
};
var res = courses.ToLookup(x => x.Id);
var res2 = courses.GroupBy(x => x.Name).ToList();
var res3 = courses.Where(x => x.Price == 10000).ToList();
bool findCourse(Course course)
{
    return course.Name.Equals("css");
}

var result = courses.Where(findCourse);
var start = courses.Where(delegate(Course course)
{
    return course.Name.StartsWith("c");
    ;

});
     

courses.Add(new Course(){Id=8});

IList list = new ArrayList();
list.Add(100);
list.Add("budud");
list.Add("Armin");
list.Add("Money");
list.Add(88);
list.Add(courses);
var intRsult = list.OfType<int>();
var classResult = list.OfType<List<Course>>();
var stringResult = list.OfType<string>();
