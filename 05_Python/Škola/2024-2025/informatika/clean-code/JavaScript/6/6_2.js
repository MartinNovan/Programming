if (grade >= 90) {
  console.log("Grade: A");
  congratulateStudent();
  updateRecords();
} else if (grade >= 80) {
  console.log("Grade: B");
  congratulateStudent();
  updateRecords();
} else if (grade >= 70) {
  console.log("Grade: C");
  updateRecords();
} else if (grade >= 60) {
  console.log("Grade: D");
  updateRecords();
} else {
  console.log("Grade: F");
  updateRecords();
}
