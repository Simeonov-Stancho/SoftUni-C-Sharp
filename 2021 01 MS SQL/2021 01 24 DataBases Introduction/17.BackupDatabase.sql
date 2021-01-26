BACKUP DATABASE SoftUni
TO DISK = 'D:\GitHub SoftUni\SoftUni-C-Sharp\2021 01 MS SQL\2021 01 24 DataBases Introduction\softuni-backup.bak'

USE MASTER

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'D:\GitHub SoftUni\SoftUni-C-Sharp\2021 01 MS SQL\2021 01 24 DataBases Introduction\softuni-backup.bak'
