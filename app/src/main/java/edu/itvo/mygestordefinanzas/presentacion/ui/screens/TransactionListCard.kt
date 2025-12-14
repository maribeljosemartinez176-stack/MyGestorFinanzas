package edu.itvo.mygestordefinanzas.presentacion.ui.screens


import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Delete
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.dp
import edu.itvo.mygestordefinanzas.domain.model.Transaction
import edu.itvo.mygestordefinanzas.domain.model.TransactionType
import java.text.SimpleDateFormat
import java.util.Date
import java.util.Locale

fun formatDate(timestamp: Long): String {
    val formatter = SimpleDateFormat("dd MMM yyyy", Locale.getDefault())
    return formatter.format(Date(timestamp))
}
@Composable
fun TransactionListCard(
    transactions: List<Transaction>,
    onDelete: (Transaction) -> Unit
) {
    if (transactions.isEmpty()) {
        Text(
            text = "No hay movimientos aún",
            style = MaterialTheme.typography.bodyMedium,
            color = MaterialTheme.colorScheme.onSurfaceVariant
        )
        return
    }

    LazyColumn(
        verticalArrangement = Arrangement.spacedBy(12.dp)
    ) {
        items(transactions) { transaction ->

            val isIncome = transaction.type == TransactionType.INCOME
            val amountColor = if (isIncome)
                MaterialTheme.colorScheme.primary
            else
                MaterialTheme.colorScheme.error

            Card(
                elevation = CardDefaults.cardElevation(4.dp),
                colors = CardDefaults.cardColors(
                    containerColor = MaterialTheme.colorScheme.surface
                )
            ) {
                Row(
                    modifier = Modifier
                        .padding(16.dp)
                        .fillMaxWidth(),
                    verticalAlignment = Alignment.CenterVertically,
                    horizontalArrangement = Arrangement.SpaceBetween
                ) {

                    // 🔹 INFO
                    Column(
                        modifier = Modifier.weight(1f)
                    ) {
                        Text(
                            text = transaction.description,
                            style = MaterialTheme.typography.titleMedium
                        )

                        Text(
                            text = formatDate(transaction.date),
                            style = MaterialTheme.typography.bodySmall,
                            color = MaterialTheme.colorScheme.onSurfaceVariant
                        )
                    }

                    // 🔹 MONTO + DELETE
                    Column(
                        horizontalAlignment = Alignment.End
                    ) {
                        Text(
                            text = if (isIncome)
                                "+ $${transaction.amount}"
                            else
                                "- $${transaction.amount}",
                            style = MaterialTheme.typography.titleMedium,
                            color = amountColor
                        )

                        IconButton(onClick = { onDelete(transaction) }) {
                            Icon(
                                imageVector = Icons.Default.Delete,
                                contentDescription = "Eliminar",
                                tint = MaterialTheme.colorScheme.error
                            )
                        }
                    }
                }
            }
        }
    }
}
