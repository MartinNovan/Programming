if grade >= 90:
    print("Grade: A")
    congratulate_student()
    update_records()
elif grade >= 80:
    print("Grade: B")
    congratulate_student()
    update_records()
elif grade >= 70:
    print("Grade: C")
    update_records()
elif grade >= 60:
    print("Grade: D")
    update_records()
else:
    print("Grade: F")
    update_records()
