package edu.itvo.mygestordefinanzas.domain.usecase

import edu.itvo.mygestordefinanzas.domain.repository.TransactionRepository
import javax.inject.Inject

class TransactionUseCases @Inject constructor(
    val add: AddTransactionUseCase,
    val delete: DeleteTransactionUseCase,
    val getAll: GetTransactionsUseCase
)
