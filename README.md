# Students-And-Teachers-Sign-Up-Form
Simple C# form for signing up as a student or as a teacher, realized with WPF and XAML

A program that serves as a Sign up form for entering data for students and teachers.
Teachers and students have similar properties:

• Name; 
• Surname; 
• Date of birth; 
• Age; 
• Personal Identification Number (PIN); 
• Gender; (listed type)

And differ in properties:

• Faculty number of the student; 
• Subject led by the teacher;

The visual part in which this information can be entered is built by using WPF and XAML.
Lists of all the users can be seen on a second window by pressing a button.
The information is stored in JSON files which serve as a local database - for loading the information when starting the application.
The age of the user is automatically calculated when entering the date of birth date. The result age cannot be less than 7 or more than 100.
The validation of the PIN is established by checking the date of birth and the gender of the person as well as the control number.

• Date check: The day, month and year are checked for a valid date.

• Gender verification: The ninth digit of the PIN is even for men and odd for women.

• Algorithm for calculating the control digit: The values from each position of thr PIN is being multiplied by the corresponding weight indicated in an array of weights.
The received multiplications are then being summed up. The result is modularly divided by 11 and if the remainder of the division is a number less than 10, it becomes a control number. If it's equal to 10, the control number is 0.
