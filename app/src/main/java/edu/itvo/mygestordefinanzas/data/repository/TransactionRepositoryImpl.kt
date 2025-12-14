package edu.itvo.mygestordefinanzas.data.repository

import edu.itvo.mygestordefinanzas.data.local.localdb.TransactionDao
import edu.itvo.mygestordefinanzas.data.local.localdb.TransactionEntity
import edu.itvo.mygestordefinanzas.domain.model.Transaction
import edu.itvo.mygestordefinanzas.domain.model.TransactionType
import edu.itvo.mygestordefinanzas.domain.repository.TransactionRepository
import kotlinx.coroutines.flow.Flow
import kotlinx.coroutines.flow.map
import javax.inject.Inject

class TransactionRepositoryImpl @Inject constructor(
    private val dao: TransactionDao
) : TransactionRepository {

    override suspend fun addTransaction(transaction: Transaction) {
        dao.insert(transaction.toEntity())
    }

    override suspend fun deleteTransaction(transaction: Transaction) {
        dao.delete(transaction.toEntity())
    }

    override fun getTransactions(): Flow<List<Transaction>> {
        return dao.getAll().map { list ->
            list.map { it.toDomain() }
        }
    }
}

/* ---------- MAPPERS ---------- */


fun Transaction.toEntity(): TransactionEntity =
    TransactionEntity(
        id = id,
        description = description,
        amount = amount,
        type = type.name, // ✅ Enum → String
        date = date
    )

fun TransactionEntity.toDomain(): Transaction =
    Transaction(
        id = id,
        description = description,
        amount = amount,
        type = TransactionType.valueOf(type), // ✅ String → Enum
        date = date
    )
