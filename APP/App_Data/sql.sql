CREATE TABLE TaskListPriority(
  ID INT PRIMARY KEY IDENTITY(1,1),
  Name NVARCHAR(20) 
  )

  INSERT TaskListPriority (Name)
  VALUES (N'Высокий'),(N'Средний'),(N'Низкий');


CREATE TABLE TaskList(
  ID INT PRIMARY KEY IDENTITY(1,1),
  Mess NVARCHAR(max),
  DeadLine DATE,
  DateStart DATE DEFAULT GETDATE(),
  DateEnd DATE,
  TaskListPriorityID INT FOREIGN KEY REFERENCES TaskListPriority(ID)
  )

  INSERT TaskList (Mess, DeadLine, TaskListPriorityID, StatusTaskID)
  VALUES (N'Первая задача', '25.07.18', 1, 0);