# Old code with repetition
# if grade >= 90:
#     print("Grade: A")
#     congratulate_student()
#     update_records()
# elif grade >= 80:
#     print("Grade: B")
#     congratulate_student()
#     update_records()
# elif grade >= 70:
#     print("Grade: C")
#     update_records()
# elif grade >= 60:
#     print("Grade: D")
#     update_records()
# else:
#     print("Grade: F")
#     update_records()

# New code without repetition
def process_grade(grade, letter_grade, should_congratulate=False):
    print(f"Grade: {letter_grade}")
    if should_congratulate:
        congratulate_student()
    update_records()

if grade >= 90:
    process_grade(grade, "A", should_congratulate=True)
elif grade >= 80:
    process_grade(grade, "B", should_congratulate=True)
elif grade >= 70:
    process_grade(grade, "C")
elif grade >= 60:
    process_grade(grade, "D")
else:
    process_grade(grade, "F")