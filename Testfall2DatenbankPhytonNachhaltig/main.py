import sqlite3
import time

start_time = time.time()

con = sqlite3.connect("Testfall2DB.sqlite")
cur = con.cursor()

# INSERT
insert_sql = "INSERT INTO Testdaten VALUES (?, ?, ?)"
for i in range(1, 50000):
    cur.execute(insert_sql, (i, "Testdatei" + str(i), i + i))

# Update
update_sql = "UPDATE Testdaten SET Wert = 0 WHERE Id = ?"
for i in range(1, 50000):
    cur.execute(update_sql, (i,))

# Delete
delete_sql = "DELETE FROM Testdaten WHERE Id = ?"
for i in range(1, 50000):
    cur.execute(delete_sql, (i,))

con.commit()
con.close()

end_time = time.time()
elapsed_time = end_time - start_time

print("Fertig")
print("Laufzeit:", elapsed_time, "Sekunden")
input()
