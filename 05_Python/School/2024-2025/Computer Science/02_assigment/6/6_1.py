# Old code with repetition
# print("Name:", user.first_name, user.last_name)
# print("Email:", user.email)
# print("Role:", user.role)

# print("Name:", user.first_name, user.last_name)
# print("Email:", user.email)
# print("Role:", user.role)

# if user.is_active:
#     print("Name:", user.first_name, user.last_name)
#     print("Email:", user.email)
#     print("Status: Active")

# New code without repetition
def print_user_info(user, include_status=False):
    print("Name:", user.first_name, user.last_name)
    print("Email:", user.email)
    if include_status:
        print("Status: Active")
    else:
        print("Role:", user.role)

print_user_info(user)
print_user_info(user)

if user.is_active:
    print_user_info(user, include_status=True)