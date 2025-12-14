
using KASD_7;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество шагов добавления заявок N: ");
        int N;
        while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
        {
            Console.Write("Ошибка! Введите положительное целое число: ");
        }
        var priorityQueue = new MyPriorityQueue<Request>();
        var allRequests = new List<Request>(); // Список всех заявок
        int requestCounter = 1;// Счётчик заявок

        using (StreamWriter logFile = new StreamWriter("log.txt", false))
        {
            logFile.WriteLine("=== Лог операций с заявками ===");
            logFile.WriteLine("Формат: ОПЕРАЦИЯ Номер_Заявки Приоритет Номер_Шага");
            logFile.WriteLine();
            for (int step = 1; step <= N; step++)
            {
                Console.WriteLine($"\n=== Шаг {step} ===");

                // Генерация случайного количества заявок (1-10)
                Random random = new Random();
                int requestsToAdd = random.Next(1, 11);
                Console.WriteLine($"Добавляется {requestsToAdd} заявок:");

                // Добавление заявок
                for (int i = 0; i < requestsToAdd; i++)
                {
                    int priority = random.Next(1, 6); // Приоритет 1-5
                    var request = new Request(priority, requestCounter, step);

                    priorityQueue.Add(request);
                    allRequests.Add(request);

                    // Логирование добавления
                    string logEntry = $"ADD {request.RequestId} {request.Priority} {step}";
                    Console.WriteLine($"  {logEntry}");
                    logFile.WriteLine(logEntry);

                    requestCounter++;
                }

                // Удаление заявки с максимальным приоритетом
                if (priorityQueue.Size() > 0)
                {
                    var removedRequest = priorityQueue.Poll();
                    removedRequest.StepRemoved = step;

                    // Логирование удаления
                    string logEntry = $"REMOVE {removedRequest.RequestId} {removedRequest.Priority} {step}";
                    Console.WriteLine($"Удалена: {logEntry}");
                    logFile.WriteLine(logEntry);
                }
                else
                {
                    Console.WriteLine("Очередь пуста, нечего удалять");
                }

                // Вывод состояния очереди
                Console.WriteLine($"Заявок в очереди: {priorityQueue.Size()}");
            }

            // Продолжение шагов только с удалением
            Console.WriteLine($"\n=== Завершение обработки (шаги {N + 1} и далее) ===");
            int removeStep = N + 1;

            while (priorityQueue.Size() > 0)
            {
                Console.WriteLine($"\n=== Шаг {removeStep} (только удаление) ===");

                var removedRequest = priorityQueue.Poll();
                removedRequest.StepRemoved = removeStep;

                // Логирование удаления
                string logEntry = $"REMOVE {removedRequest.RequestId} {removedRequest.Priority} {removeStep}";
                Console.WriteLine($"Удалена: {logEntry}");
                logFile.WriteLine(logEntry);

                Console.WriteLine($"Заявок в очереди: {priorityQueue.Size()}");
                removeStep++;
            }

            Console.WriteLine("\n=== Обработка завершена ===");

            // Анализ результатов
            AnalyzeRequests(allRequests);
        }

        Console.WriteLine("\nЛог операций сохранен в файл log.txt");
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    // Анализ заявок и поиск максимального времени ожидания
    static void AnalyzeRequests(List<Request> requests)
    {
        if (requests.Count == 0)
        {
            Console.WriteLine("Нет заявок для анализа");
            return;
        }

        Request maxWaitingRequest = null;
        int maxWaitingTime = -1;

        // Находим заявку с максимальным временем ожидания
        foreach (var request in requests)
        {
            if (request.StepRemoved.HasValue)
            {
                int waitingTime = request.WaitingTime;
                if (waitingTime > maxWaitingTime)
                {
                    maxWaitingTime = waitingTime;
                    maxWaitingRequest = request;
                }
            }
        }

        // Вывод результатов
        Console.WriteLine("\n=== АНАЛИЗ ЗАЯВОК ===");
        Console.WriteLine($"Всего обработано заявок: {requests.Count}");

        if (maxWaitingRequest != null)
        {
            Console.WriteLine($"\nЗаявка с максимальным временем ожидания:");
            Console.WriteLine($"  Номер заявки: {maxWaitingRequest.RequestId}");
            Console.WriteLine($"  Приоритет: {maxWaitingRequest.Priority}");
            Console.WriteLine($"  Шаг добавления: {maxWaitingRequest.StepAdded}");
            Console.WriteLine($"  Шаг удаления: {maxWaitingRequest.StepRemoved}");
            Console.WriteLine($"  Время ожидания: {maxWaitingTime} шагов");

            // Дополнительная статистика
            PrintStatistics(requests);
        }
        else
        {
            Console.WriteLine("Не удалось найти заявку с максимальным временем ожидания");
        }
    }

    // Вывод дополнительной статистики
    static void PrintStatistics(List<Request> requests)
    {
        Console.WriteLine("\n=== ДОПОЛНИТЕЛЬНАЯ СТАТИСТИКА ===");

        // Группировка по приоритетам
        var priorityGroups = new Dictionary<int, List<Request>>();
        for (int i = 1; i <= 5; i++)
        {
            priorityGroups[i] = new List<Request>();
        }

        foreach (var request in requests)
        {
            if (request.StepRemoved.HasValue)
            {
                priorityGroups[request.Priority].Add(request);
            }
        }

        Console.WriteLine("Среднее время ожидания по приоритетам:");
        for (int i = 1; i <= 5; i++)
        {
            var group = priorityGroups[i];
            if (group.Count > 0)
            {
                double avgWaitingTime = group.Average(r => r.WaitingTime);
                Console.WriteLine($"  Приоритет {i}: {group.Count} заявок, среднее время = {avgWaitingTime:F2} шагов");
            }
            else
            {
                Console.WriteLine($"  Приоритет {i}: 0 заявок");
            }
        }

        // Общее среднее время ожидания
        var processedRequests = requests.Where(r => r.StepRemoved.HasValue).ToList();
        if (processedRequests.Count > 0)
        {
            double overallAvg = processedRequests.Average(r => r.WaitingTime);
            Console.WriteLine($"\nОбщее среднее время ожидания: {overallAvg:F2} шагов");
        }
    }
}

