# Old code with complex logic
# def process_transactions(transactions):
#     for transaction in transactions:
#         if transaction['type'] == 'credit':
#             if transaction['amount'] > 1000:
#                 apply_bonus(transaction)
#             else:
#                 apply_standard_processing(transaction)
#         elif transaction['type'] == 'debit':
#             if transaction['amount'] > 500:
#                 require_approval(transaction)
#             else:
#                 deduct_amount(transaction)
#         else:
#             print("Unknown transaction type:", transaction['type'])

# New code with simplified logic
def process_transactions(transactions):
    for transaction in transactions:
        if transaction['type'] == 'credit':
            process_credit(transaction)
        elif transaction['type'] == 'debit':
            process_debit(transaction)
        else:
            print("Unknown transaction type:", transaction['type'])

def process_credit(transaction):
    if transaction['amount'] > 1000:
        apply_bonus(transaction)
    else:
        apply_standard_processing(transaction)

def process_debit(transaction):
    if transaction['amount'] > 500:
        require_approval(transaction)
    else:
        deduct_amount(transaction)