import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.concurrent.TimeUnit;

public class Testfall2DatenbankJavaNachhaltig {

    public static void main(String[] args) throws IOException, SQLException {
        long startTime = System.nanoTime();
        String currentPath = new java.io.File(".").getCanonicalPath();
        System.out.print(currentPath);
        String conString = "jdbc:sqlite:" + currentPath + "\\src\\Database\\Testfall2.sqlite";
        
        Connection con = DriverManager.getConnection(conString);

        // INSERT
        String insertSql = "INSERT INTO Testdaten VALUES (?, ?, ?)";
        PreparedStatement insertStmt = con.prepareStatement(insertSql);
        for (int i = 1; i <= 50000; i++) {
            insertStmt.setInt(1, i);
            insertStmt.setString(2, "Testdatei" + i);
            insertStmt.setInt(3, i + i);
            insertStmt.executeUpdate();
        }
        insertStmt.close();

        // UPDATE
        String updateSql = "UPDATE Testdaten SET Wert = 0 WHERE Id = ?";
        PreparedStatement updateStmt = con.prepareStatement(updateSql);
        for (int i = 1; i <= 50000; i++) {
            updateStmt.setInt(1, i);
            updateStmt.executeUpdate();
        }
        updateStmt.close();

        // DELETE
        String deleteSql = "DELETE FROM Testdaten WHERE Id = ?";
        PreparedStatement deleteStmt = con.prepareStatement(deleteSql);
        for (int i = 1; i <= 50000; i++) {
            deleteStmt.setInt(1, i);
            deleteStmt.executeUpdate();
        }
        deleteStmt.close();

        con.close();

        long endTime = System.nanoTime();
        long elapsedTime = endTime - startTime;
        long seconds = TimeUnit.NANOSECONDS.toSeconds(elapsedTime);
        System.out.println("Fertig");
        System.out.println("Laufzeit: " + seconds + " Sekunden");
    }
}
