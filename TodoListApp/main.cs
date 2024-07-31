using System;
using System.Collections.Generic;
using TodoList;
using TodoListApp;

namespace TodoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            bool keepRunning = true;
            Console.WriteLine("Todo list 3000");
            //criando a lista pras tarefas
            List<TaskTodo> list = new List<TaskTodo>();
            while (keepRunning)
            {
                string message = "";
                ConsoleColor messageColor = ConsoleColor.White;
                Console.WriteLine("1 - Adcionar tarefas\n2 - ver a lista de tarefas pendentes\n3 - para marcar uma tarefa como concluida\n4 - excluir uma tarefa\n5 - sair");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        var result = AddTask();
                        if (result.Task != null)
                        {
                            list.Add(result.Task);
                            message = result.Message;
                            messageColor = ConsoleColor.Green;
                        }
                        break;
                    case "2":
                        ListTasks.PrintTaskList(list);
                        messageColor = ConsoleColor.Green;
                        break;
                    case "3":
                        ListTasks.MarkAsFinished(list);
                        break;
                    case "4":
                        DeletTaskt(list);
                        break;
                    case "5":
                        message = "saindo...";
                        messageColor = ConsoleColor.Green;
                        keepRunning = false;
                        break;
                    default:
                        message = "entrada invalida";
                        messageColor = ConsoleColor.Yellow;
                        break;

                }
                // Console.Clear();
                Console.ForegroundColor = messageColor;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        public static TaskResult AddTask()
        {
            TaskTodo tasks = new TaskTodo();
            Console.Write("Titulo da tarefa: ");
            string TaskName = Console.ReadLine();
            if (string.IsNullOrEmpty(TaskName))
            {
                //usando esse metodo para tratar possiveis erros do usuario
                return new TaskResult { Task = null, Message = "O título da tarefa não pode ser vazio." };
            }
            tasks.TaskName = TaskName;
            Console.Write("descrição da: ");
            tasks.Description = Console.ReadLine();
            return new TaskResult { Task = tasks, Message = "tarefa cria com sucesso!" };
        }
        public static void DeletTaskt(List<TaskTodo> list)
        {
            Console.Write("Qual tarefa deseja apagar: ");
            string tarefa = Console.ReadLine();

            TaskTodo taskDelete = null;
            foreach (var task in list)
            {
                if (task.TaskName == tarefa)
                {
                    taskDelete = task;
                    break;
                }
            }
            if (taskDelete == null)
            {
                Console.WriteLine("Tarefa não encontrada!");
                return;
            }
            Console.WriteLine($"Deseja apagar {taskDelete.TaskName}?[s/n]");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "s")
            {
                list.Remove(taskDelete);
                Console.WriteLine("Tarefa apagada com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }
    }

    public class TaskResult
    {
        public TaskTodo Task;
        public string Message;
    }

}

/*dotnet build
dotnet run
*/