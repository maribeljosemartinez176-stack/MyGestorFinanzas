package edu.itvo.mygestordefinanzas.domain.model

data class Transaction(
    val id: Long = 0,
    val description: String,
    val amount: Double,
    val type: TransactionType,
    val date: Long
)

enum class TransactionType {
    INCOME,
    EXPENSE
}
