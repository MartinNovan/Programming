# Old code with inconsistent formatting
# employees=[{'id':1,'name':'John Doe'},{'id':2,'name':'Jane Smith'}]
# for i in range(len(employees)):
#     print("Employee ID:"+str(employees[i]['id'])+", Name:"+employees[i]['name'])

# New code with consistent formatting
employees = [{'id': 1, 'name': 'John Doe'}, {'id': 2, 'name': 'Jane Smith'}]
for i in range(len(employees)):
    print("Employee ID: " + str(employees[i]['id']) + ", Name: " + employees[i]['name'])