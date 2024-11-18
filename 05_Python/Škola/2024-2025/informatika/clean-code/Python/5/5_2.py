def process_transactions(transactions):
    for transaction in transactions:
        if transaction['type'] == 'credit':
            if transaction['amount'] > 1000:
                apply_bonus(transaction)
            else:
                apply_standard_processing(transaction)
        elif transaction['type'] == 'debit':
            if transaction['amount'] > 500:
                require_approval(transaction)
            else:
                deduct_amount(transaction)
        else:
            print("Unknown transaction type:", transaction['type'])
