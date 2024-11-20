import random  # This is needed for random selection

# Here we have all subjects and how many times they should appear in the schedule
SUBJECTS = {
    'CJL': 3, 'OBN': 1, 'ANJ': 3, 'MAT': 4, 'PE': 2,
    'ASW': 2, 'POS': 3, 'PRG': 3, 'MIT': 2, 'INF': 2,
    'VAP': 2, 'MSW': 2
}

DAYS = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri']  # Days of the week
LUNCH = 'ㅤ'  # This is a special invisible character for lunch

def create_empty_schedule():
    # Create an empty schedule where each day has 10 empty hours
    schedule = {day: [''] * 10 for day in DAYS}
    schedule['Wed'] = [' '] * 10  # Wednesday is free, so we fill it with spaces
    return schedule

def find_free_hour(schedule, day):
    # This function finds the first free hour in a given day
    return next((i for i, hour in enumerate(schedule[day]) if hour == ''), None)

def add_lunch(schedule):
    # Add lunch randomly between the 4th and 8th hour for each day except Wednesday
    for day in ['Mon', 'Tue', 'Thu', 'Fri']:
        lunch_hour = random.randint(3, 7)
        schedule[day][lunch_hour] = LUNCH

def add_pe(schedule):
    # Add two PE hours in a random day
    pe_day = random.choice(['Mon', 'Tue', 'Thu', 'Fri'])
    pe_hour = find_free_hour(schedule, pe_day)
    if pe_hour is not None and pe_hour < 9:
        schedule[pe_day][pe_hour] = 'PE'
        schedule[pe_day][pe_hour + 1] = 'PE'

def add_subjects(schedule):
    # Add all other subjects to the schedule
    for subject, count in SUBJECTS.items():
        if subject != 'PE':  # PE has already been added, so we skip it
            for _ in range(count):
                while True:
                    day = random.choice(['Mon', 'Tue', 'Thu', 'Fri'])
                    hour = find_free_hour(schedule, day)
                    if hour is not None:
                        schedule[day][hour] = subject
                        break

def arrange_subjects(schedule):
    # Arrange subjects so that there are no unnecessary gaps
    for day in ['Mon', 'Tue', 'Thu', 'Fri']:
        subjects = [s for s in schedule[day] if s != '' and s != LUNCH]
        lunch_index = schedule[day].index(LUNCH)
        
        # Arrange subjects before lunch
        for i in range(lunch_index):
            schedule[day][i] = subjects[i] if i < len(subjects) else ''
        
        # Arrange subjects after lunch
        for i in range(lunch_index + 1, 10):
            schedule[day][i] = subjects[i - 1] if i - 1 < len(subjects) else ''

def check_hour_count(schedule):
    # Check if each day has at least 4 hours
    for day in ['Mon', 'Tue', 'Thu', 'Fri']:
        hour_count = sum(1 for s in schedule[day] if s != '' and s != LUNCH)
        while hour_count < 4:
            # If not, take an hour from the longest day and add it here
            longest_day = max(['Mon', 'Tue', 'Thu', 'Fri'], key=lambda d: sum(1 for s in schedule[d] if s != '' and s != LUNCH))
            if sum(1 for s in schedule[longest_day] if s != '' and s != LUNCH) > 4:
                for i, subject in enumerate(schedule[longest_day]):
                    if subject not in ['', 'PE', LUNCH]:
                        hour = find_free_hour(schedule, day)
                        if hour is not None:
                            schedule[day][hour] = subject
                            schedule[longest_day][i] = ''
                            hour_count += 1
                            break
            if hour_count == 4:
                break

def generate_schedule():
    # Here we put everything together and create a complete schedule
    schedule = create_empty_schedule()
    add_lunch(schedule)
    add_pe(schedule)
    add_subjects(schedule)
    arrange_subjects(schedule)
    check_hour_count(schedule)
    return schedule

def print_schedule(schedule):
    # This function nicely prints the schedule to the console
    print("+-----+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+")
    print("| Day | 1st hour   | 2nd hour   | 3rd hour   | 4th hour   | 5th hour   | 6th hour   | 7th hour   | 8th hour   | 9th hour   | 10th hour  |")
    print("|     | 08:00-08:45 | 08:55-09:40 | 10:00-10:45 | 10:55-11:40 | 11:50-12:35 | 12:45-13:30 | 13:40-14:25 | 14:30-15:15 | 15:20-16:05 | 16:10-16:55 |")
    print("+-----+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+")

    for day in DAYS:
        print(f"| {day}  |", end="")
        for subject in schedule[day]:
            if subject == LUNCH:
                print("             |", end="")
            else:
                print(f" {subject:11} |", end="")
        print("\n+-----+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+")

# Here we run everything
schedule = generate_schedule()
print_schedule(schedule) 