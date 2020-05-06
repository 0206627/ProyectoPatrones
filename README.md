# mini social network

To install the desktop app and use it in any computer, you have to:

<ol>
<li>Clone this repository.</li>
<li>After the download, open the solution file from Visual Studio.</li>
  <ol>
  <li>There is a folder named <i>images</i> with all the pictures used in the project (such as logos and base pictures). </li>
  <li>For these images to work, you need to modify the attributed named <i>imageRoute</i> in the static class <i>Configuration</i> (in the file <i>Configuration.cs</i>) inside the project <i>MiniFacebookVisual</i> for the project to reference the folder mentioned above.
  <li>For the references to work, due to conflicts between net and core projects, you need to follow these steps:</li>
    <ol>
    <li>Compile both projects -<i>Core</i> and <i>DAL</i>- from solution.</li>
    <li>In Visual Studio, right click the project <i>MiniFacebookVisual</i> --> Add --> Reference. When the new window appears, click the "Examine" button:</li>
      <ol>
      <li>Go to the folder where the repository is saved, then to the folder of the project <i>Core</i> --> bin --> Debug --> net472 --> <i>Core.dll</i></li>
      <li>Click again in "Examine" and go to the repository folder, then to the folder of the project <i>DAL</i> --> bin --> Debug --> net472 --> <i>DAL.dll</i></li>
      </ol>
    <li>Click "Accept" to add references.</li>
    </ol>
  </ol>
  <li>To add the database you need to use SQL Server,</li>
  <ol>
  <li>To create your database, use the file from the repository folder <i>dataBaseScripts</i>. With that file you create your database in SQL Server.</li>
  <li>To connect the database in VisualStudio, in the file <i>Configuration.cs</i>, change the attribute <i>connectionString</i> with the connection string from your database.</li>
  </ol>
  <br/>
  ** The database already includes some data to use. 
</ol>
