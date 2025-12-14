package edu.itvo.mygestordefinanzas.domain.usecase


import edu.itvo.mygestordefinanzas.domain.model.Transaction
import edu.itvo.mygestordefinanzas.domain.repository.TransactionRepository
import javax.inject.Inject

class DeleteTransactionUseCase @Inject constructor(
    private val repository: TransactionRepository
) {
    suspend operator fun invoke(transaction: Transaction) {
        repository.deleteTransaction(transaction)
    }
}
