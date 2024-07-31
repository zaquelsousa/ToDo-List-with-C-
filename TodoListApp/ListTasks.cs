using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList;

namespace TodoListApp
{
    public class ListTasks
    {
        //metod para listar as tarefas
        public static void PrintTaskList(List<TaskTodo> tasks)
        {
            Console.WriteLine("Todas as tarefas: ");
            foreach (var task in tasks)
            {
                string Iscompleted;
                if (task.Iscompleted != false)
                {
                    Iscompleted = "Concluida";
                }
                else
                {
                    Iscompleted = "Pendente";
                }
                Console.WriteLine($"Título: {task.TaskName} |Descrição: {task.Description} |{Iscompleted}");
            }
        }
        public static void MarkAsFinished(List<TaskTodo> tasks)
        {
            Console.Write("Qual tarefa foi completa: ");
            string tarefa = Console.ReadLine();

            TaskTodo concluded = null;
            foreach (var task in tasks)
            {
                if (task.TaskName == tarefa)
                {
                    concluded = task;
                    break;
                }
            }
            if (concluded == null)
            {
                Console.WriteLine("Tarefa não encontrada!");
                return;
            }

            Console.WriteLine($"Deseja marcar {concluded.TaskName} como concluida?[s/n]");
            string userInput = Console.ReadLine();
            if(userInput.ToLower() == "s"){
                concluded.Iscompleted = true;
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }

        }


    }
}