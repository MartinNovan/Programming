# Old code
# if employee.years_of_service > 10:
#     print("Eligible for long-term service award.")
# else:
#     print("Not eligible for award.")

# New code with named constant
LONG_TERM_SERVICE_THRESHOLD = 10

if employee.years_of_service > LONG_TERM_SERVICE_THRESHOLD:
    print("Eligible for long-term service award.")
else:
    print("Not eligible for award.")