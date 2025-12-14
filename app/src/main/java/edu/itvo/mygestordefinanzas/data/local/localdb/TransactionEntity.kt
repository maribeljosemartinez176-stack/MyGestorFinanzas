package edu.itvo.mygestordefinanzas.data.local.localdb

import androidx.room.Entity
import androidx.room.PrimaryKey
import edu.itvo.mygestordefinanzas.domain.model.TransactionType

@Entity(tableName = "transactions")
data class TransactionEntity(
    @PrimaryKey(autoGenerate = true)
    val id: Long = 0,
    val description: String,
    val amount: Double,
    val type: String,
    val date: Long
)
