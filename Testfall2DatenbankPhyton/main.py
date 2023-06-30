import sqlite3
import time

start_time = time.time()

con = sqlite3.connect("Testfall2DB.sqlite")
cur = con.cursor()

# INSERT
for i in range(1, 50000):
    cur.execute("INSERT INTO Testdaten VALUES (?, ?, ?)", (i, "Testdatei" + str(i), i + i))

# Update
for i in range(1, 50000):
    cur.execute("UPDATE Testdaten SET Wert = 0 WHERE Id = ?", (i,))

# Delete
for i in range(1, 50000):
    cur.execute("DELETE FROM Testdaten WHERE Id = ?", (i,))

con.commit()
con.close()

end_time = time.time()
elapsed_time = end_time - start_time

print("Fertig")
print("Laufzeit:", elapsed_time, "Sekunden")
input()