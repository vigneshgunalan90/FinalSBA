using ProjectManager.DataLayer;
using ProjectManager.Shared.ServiceContracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ProjectManager.Mapper
{
    public class ProjectManagerService
    {
        public bool AddTask(TaskModel taskModel)
        {
            EntityMapper<TaskModel, Task> mapObj = new EntityMapper<TaskModel, Task>();
            var task = mapObj.Translate(taskModel);
            return ProjectManagerDataLayer.InsertTask(task);
        }

        public bool AddProject(ProjectModel projectModel)
        {
            EntityMapper<ProjectModel, Project> mapObj = new EntityMapper<ProjectModel, Project>();
            var project = mapObj.Translate(projectModel);
            if(project.Start_Date == default(DateTime))
            {
                project.Start_Date = null;
            }
            if (project.End_Date == default(DateTime))
            {
                project.End_Date = null;
            }
            return ProjectManagerDataLayer.InsertProject(project);
        }

        public bool AddUser(UserModel userModel)
        {
            EntityMapper<UserModel, User> mapObj = new EntityMapper<UserModel, User>();
            var user = mapObj.Translate(userModel);
            return ProjectManagerDataLayer.InsertUser(user);
        }

        public bool AddParentTask(ParentTaskModel parentTaskModel)
        {
            EntityMapper<ParentTaskModel, ParentTask> mapObj = new EntityMapper<ParentTaskModel, ParentTask>();
            var parentTask = mapObj.Translate(parentTaskModel);
            return ProjectManagerDataLayer.InsertParentTask(parentTask);
        }

        public List<TaskModel> GetTasks()
        {
            EntityMapper<Task, TaskModel> mapObj = new EntityMapper<Task, TaskModel>();
            List<Task> taskList = ProjectManagerDataLayer.GetTasks();
            List<TaskModel> taskModels = new List<TaskModel>();
            foreach (var task in taskList)
            {
                var taskModel = mapObj.Translate(task);
                taskModel.ParentTaskName = ProjectManagerDataLayer.GetParentTask(task.Parent_ID).ParentTaskName;
                taskModels.Add(taskModel);                
            }

            return taskModels;
        }

        public List<UserModel> GetUsers()
        {
            EntityMapper<User, UserModel> mapObj = new EntityMapper<User, UserModel>();
            List<User> userList = ProjectManagerDataLayer.GetUsers();
            List<UserModel> userModels = new List<UserModel>();
            foreach (var user in userList)
            {
                userModels.Add(mapObj.Translate(user));
            }

            return userModels;
        }


        public List<ProjectModel> GetProjects()
        {
            EntityMapper<Project, ProjectModel> mapObj = new EntityMapper<Project, ProjectModel>();
            List<Project> projectList = ProjectManagerDataLayer.GetProjects();
            List<ProjectModel> projectModels = new List<ProjectModel>();
            foreach (var project in projectList)
            {
                var projectModel = mapObj.Translate(project);
                projectModel.NoOfTasks = ProjectManagerDataLayer.GetTasks().Where(x => x.Project_ID == projectModel.Project_ID).ToList().Count;
                projectModel.CompletedTasks = ProjectManagerDataLayer.GetTasks().Where(x => x.Project_ID == projectModel.Project_ID && x.End_Date.Date <= DateTime.Now.Date).ToList().Count;
                projectModels.Add(projectModel);
            }

            return projectModels;
        }

        public List<ParentTaskModel> GetParentTasks()
        {
            EntityMapper<ParentTask, ParentTaskModel> mapObj = new EntityMapper<ParentTask, ParentTaskModel>();
            List<ParentTask> parentTaskList = ProjectManagerDataLayer.GetParentTasks();
            List<ParentTaskModel> parentTaskModels = new List<ParentTaskModel>();
            foreach (var parent in parentTaskList)
            {
                var parentTaskModel = mapObj.Translate(parent);                
                parentTaskModels.Add(parentTaskModel);
            }

            return parentTaskModels;
        }

        public List<UserModel> SearchUsers(string searchKeyWord, string sortBy)
        {
            EntityMapper<User, UserModel> mapObj = new EntityMapper<User, UserModel>();
            List<User> userList = ProjectManagerDataLayer.SearchUsers(searchKeyWord, sortBy);
            List<UserModel> userModels = new List<UserModel>();
            foreach (var user in userList)
            {
                userModels.Add(mapObj.Translate(user));
            }

            return userModels;
        }

        public List<ProjectModel> SearchProjects(string searchKeyWord, string sortBy)
        {
            EntityMapper<Project, ProjectModel> mapObj = new EntityMapper<Project, ProjectModel>();
            List<Project> projectList = ProjectManagerDataLayer.SearchProjects(searchKeyWord, sortBy);
            List<ProjectModel> projectModels = new List<ProjectModel>();
            foreach (var project in projectList)
            {
                projectModels.Add(mapObj.Translate(project));
            }

            return projectModels;
        }

        public UserModel GetUser(int userID)
        {
            EntityMapper<User, UserModel> mapObj = new EntityMapper<User, UserModel>();
            User user = ProjectManagerDataLayer.GetUser(userID);
            UserModel userModel = new UserModel();
            userModel = mapObj.Translate(user);
           
            return userModel;
        }

        public ProjectModel GetProject(int projectID)
        {
            EntityMapper<Project, ProjectModel> mapObj = new EntityMapper<Project, ProjectModel>();
            Project project = ProjectManagerDataLayer.GetProject(projectID);
            ProjectModel projectModel = new ProjectModel();
            projectModel = mapObj.Translate(project);

            return projectModel;
        }

        public TaskModel GetTask(int taskID)
        {
            EntityMapper<Task, TaskModel> mapObj = new EntityMapper<Task, TaskModel>();
            Task task = ProjectManagerDataLayer.GetTask(taskID);
            TaskModel taskModel = new TaskModel();
            taskModel = mapObj.Translate(task);

            return taskModel;
        }

        public ParentTaskModel GetParentTask(int parentID)
        {
            EntityMapper<ParentTask, ParentTaskModel> mapObj = new EntityMapper<ParentTask, ParentTaskModel>();
            ParentTask parentTask = ProjectManagerDataLayer.GetParentTask(parentID);
            ParentTaskModel parentTaskModel = new ParentTaskModel();
            parentTaskModel = mapObj.Translate(parentTask);

            return parentTaskModel;
        }

        public bool UpdateUser(UserModel userModel)
        {
            EntityMapper<UserModel, User> mapObj = new EntityMapper<UserModel, User>();
            var user = mapObj.Translate(userModel);
            return ProjectManagerDataLayer.UpdateUser(user);
        }

        public bool UpdateProject(ProjectModel projectModel)
        {
            EntityMapper<ProjectModel, Project> mapObj = new EntityMapper<ProjectModel, Project>();
            var project = mapObj.Translate(projectModel);
            return ProjectManagerDataLayer.UpdateProject(project);
        }

        public bool UpdateTask(TaskModel taskModel)
        {
            EntityMapper<TaskModel, Task> mapObj = new EntityMapper<TaskModel, Task>();
            var task = mapObj.Translate(taskModel);
            return ProjectManagerDataLayer.UpdateTask(task);
        }

        public bool UpdateParentTask(ParentTaskModel parentTaskModel)
        {
            EntityMapper<ParentTaskModel, ParentTask> mapObj = new EntityMapper<ParentTaskModel, ParentTask>();
            var parentTask = mapObj.Translate(parentTaskModel);
            return ProjectManagerDataLayer.UpdateParentTask(parentTask);
        }

        public bool DeleteProject(int projectID)
        {
            return ProjectManagerDataLayer.DeleteProject(projectID);
        }

        public bool DeleteUser(int userID)
        {
            return ProjectManagerDataLayer.DeleteUser(userID);
        }        
    }
}
