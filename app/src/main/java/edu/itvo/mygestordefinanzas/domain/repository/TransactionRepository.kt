package edu.itvo.mygestordefinanzas.domain.repository

import edu.itvo.mygestordefinanzas.domain.model.Transaction
import kotlinx.coroutines.flow.Flow

interface TransactionRepository {

    suspend fun addTransaction(transaction: Transaction)

    suspend fun deleteTransaction(transaction: Transaction)
    fun getTransactions(): Flow<List<Transaction>>
}
