import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.TimeUnit;

public class Testfall2DatenbankJava {

    public static void main(String[] args) throws IOException, SQLException {
        long startTime = System.nanoTime();
        String currentPath = new java.io.File(".").getCanonicalPath();
        System.out.print(currentPath);
        String conString = "jdbc:sqlite:" + currentPath + "\\src\\Database\\Testfall2.sqlite";
        
        Connection con = DriverManager.getConnection(conString);

       	// INSERT
        for (int i = 1; i <= 50000; i++) {
            String sql = "INSERT INTO Testdaten VALUES (?, ?, ?)";
            PreparedStatement stmt = con.prepareStatement(sql);
            stmt.setInt(1, i);
            stmt.setString(2, "Testdatei" + i);
            stmt.setInt(3, i + i);
            stmt.executeUpdate();
            stmt.close();
        }

        // Update
        for (int i = 1; i <= 50000; i++) {
            String sql = "UPDATE Testdaten SET Wert = 0 WHERE Id = ?";
            PreparedStatement stmt = con.prepareStatement(sql);
            stmt.setInt(1, i);
            stmt.executeUpdate();
            stmt.close();
        }

        // Delete
        for (int i = 1; i <= 50000; i++) {
            String sql = "DELETE FROM Testdaten WHERE Id = ?";
            PreparedStatement stmt = con.prepareStatement(sql);
            stmt.setInt(1, i);
            stmt.executeUpdate();
            stmt.close();
        }
      

        long endTime = System.nanoTime();
        long elapsedTime = endTime - startTime;
        long seconds = TimeUnit.NANOSECONDS.toSeconds(elapsedTime);
        System.out.println("Fertig");
        System.out.println("Laufzeit: " + seconds + " Sekunden");
    }
}
