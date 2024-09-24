--create database name Crime management
create database crime 
alter database crime modify name= Crimemanagement

-- Create tables 
CREATE TABLE Crime ( 
    CrimeID INT PRIMARY KEY, 
    IncidentType VARCHAR(255), 
    Incidentdate  Date, 
    Location VARCHAR(255), 
    Description TEXT, 
    Status VARCHAR(20)
)
alter table Crime
alter column Status varchar(30);
CREATE TABLE Victim ( 
    VictimID INT PRIMARY KEY, 
    CrimeID INT, 
    Name VARCHAR(255), 
	Age varchar(10),
    ContactInfo VARCHAR(255), 
    Injuries VARCHAR(255), 
    FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID) 
);
CREATE TABLE Suspect ( 
    SuspectID INT PRIMARY KEY, 
    CrimeID INT, 
    Name VARCHAR(255),
	Age varchar(10),
    Description TEXT, 
    CriminalHistory TEXT, 
    FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID) 
);
-- Insert sample data 
INSERT INTO Crime (CrimeID, IncidentType, IncidentDate, Location, Description, Status) 
VALUES 
    (1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'), 
    (2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', 'Under Investigation'), 
    (3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed');
	select*from crime

INSERT INTO Victim (VictimID, CrimeID, Name, Age,ContactInfo, Injuries) 
VALUES 
    (1, 1, 'John Doe',30, 'johndoe@example.com', 'Minor injuries'), 
    (2, 2, 'Jane Smith',33, 'janesmith@example.com', 'Deceased'),
	(3, 3, 'Alice Johnson',35, 'alicejohnson@example.com', 'None');

INSERT INTO Suspect (SuspectID, CrimeID, Name,Age, Description, CriminalHistory) 
VALUES 
(1, 1, 'Robber 1',30, 'Armed and masked robber', 'Previous robbery convictions'), 
(2, 2, 'Unknown',33, 'Investigation ongoing', NULL), 
(3, 3, 'Suspect 1',35, 'Shoplifting suspect', 'Prior shoplifting arrests');

--Solve the below queries: 
--1. Select all open incidents. 
select * from crime where status ='open';
--2. Find the total number of incidents.
SELECT COUNT(*) AS TotalIncidents 
FROM Crime;

--3. List all unique incident types. 
SELECT DISTINCT IncidentType 
FROM Crime;

--4. Retrieve incidents that occurred between '2023-09-01' and '2023-09-10'. 
SELECT * 
FROM Crime 
WHERE IncidentDate BETWEEN '2023-09-01' AND '2023-09-10';

--5. List persons involved in incidents in descending order of age.
select v.Name,v.age,s.Name,s.Age from victim v full join suspect s on v.VictimID=s.SuspectID  order by v.Age desc;
--6. Find the average age of persons involved in incidents. 
SELECT AVG(cast(Age as int)) AS AverageAge 
FROM (
    SELECT Age FROM Victim UNION all
    SELECT Age FROM Suspect
) AS Persons;

--7. List incident types and their counts, only for open cases. 
SELECT IncidentType, COUNT(*) AS IncidentCount 
FROM Crime 
WHERE Status = 'Open' 
GROUP BY IncidentType;

--8. Find persons with names containing 'Doe'.


SELECT VictimID , Name, Age FROM Victim 
WHERE Name LIKE '%Doe%'
UNION all
SELECT SuspectID , Name, Age
FROM Suspect 
WHERE Name LIKE '%Doe%';



--9. Retrieve the names of persons involved in open cases and closed cases. 
SELECT v.Name as victim_name , s.Name as suspect_name
FROM Crime c LEFT JOIN Victim v ON c.CrimeID = v.CrimeID
LEFT JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE c.Status IN ('Open', 'Closed');

--10. List incident types where there are persons aged 30 or 35 involved. 
SELECT c.IncidentType FROM Crime c
JOIN Victim v ON c.CrimeID = v.CrimeID
WHERE v.Age IN ('30', '35')
UNION
SELECT c.IncidentType FROM Crime c
JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE s.Age IN ('30', '35');

--11. Find persons involved in incidents of the same type as 'Robbery'. 
SELECT v.Name AS VictimName, s.Name AS SuspectName
FROM Crime c
LEFT JOIN Victim v ON c.CrimeID = v.CrimeID
LEFT JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE c.IncidentType = 'Robbery';

--12. List incident types with more than one open case. 
SELECT IncidentType, COUNT(*) FROM Crime 
WHERE Status = 'Open' 
GROUP BY IncidentType 
HAVING COUNT(*) > 1;
-- giving zero row affected so adding value to get a appropriate answer
INSERT INTO Crime (CrimeID, IncidentType, IncidentDate, Location, Description, Status) 
VALUES 
    (4, 'Robbery', '2023-09-20', '124 Main St, Cityville', 'Armed robbery at a jewellary store', 'Open')
--13. List all incidents with suspects whose names also appear as victims in other incidents. 
SELECT c.CrimeID, c.IncidentType, s.Name AS Suspect_Name 
FROM Suspect s 
JOIN Crime c ON s.CrimeID = c.CrimeID
where s.name in (select name from victim)

--14.  Retrieve all incidents along with victim and suspect details.
SELECT c.CrimeID, c.IncidentType, c.IncidentDate, v.Name AS Victim_Name, s.Name AS Suspect_Name
FROM Crime c
LEFT JOIN Victim v ON c.CrimeID = v.CrimeID
LEFT JOIN Suspect s ON c.CrimeID = s.CrimeID;

--15. Find incidents where the suspect is older than any victim. 
SELECT c.CrimeID, c.IncidentType, s.Name AS Suspect_Name, v.Name AS Victim_Name FROM Crime c
JOIN Victim v ON c.CrimeID = v.CrimeID
JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE CAST(s.Age AS INT) > CAST(v.Age AS INT);


--16. Find suspects involved in multiple incidents: 
SELECT Name, COUNT(*) AS Incident_Count 
FROM Suspect s
GROUP BY Name 
HAVING COUNT(*) > 1;

---- giving zero row affected so adding value to get a appropriate answer

INSERT INTO Suspect (SuspectID, CrimeID, Name,Age, Description, CriminalHistory) 
VALUES 
(4, 4, 'Robber 1',40, 'murder', 'Previous robbery convictions')


--17. List incidents with no suspects involved. 
SELECT c.CrimeID, c.IncidentType 
FROM Crime c
LEFT JOIN Suspect s ON c.CrimeID = s.CrimeID
WHERE s.SuspectID IS NULL;



--18. List all cases where at least one incident is of type 'Homicide' and all other incidents are of type 'Robbery'. 

SELECT CrimeID, IncidentType, IncidentDate, Location, CAST(Description AS VARCHAR(MAX)) , Status 
FROM Crime WHERE IncidentType = 'Homicide'
UNION 
SELECT CrimeID, IncidentType, IncidentDate, Location, CAST(Description AS VARCHAR(MAX)) , Status 
FROM Crime WHERE IncidentType = 'Robbery';



--19. Retrieve a list of all incidents and the associated suspects, showing suspects for each incident, or 'No Suspect' if there are none. 
SELECT c.CrimeID, c.IncidentType, COALESCE(s.Name, 'No Suspect') AS Suspect_Name 
FROM Crime c
LEFT JOIN Suspect s ON c.CrimeID = s.CrimeID;


--20. List all suspects who have been involved in incidents with incident types 'Robbery' or 'Assault'
select s.SuspectID, s.CrimeID, s.Name,s.Age, s.Description, s.CriminalHistory from suspect s
JOIN Crime c ON s.CrimeID = c.CrimeID
WHERE c.IncidentType IN ('Robbery', 'Assault');
