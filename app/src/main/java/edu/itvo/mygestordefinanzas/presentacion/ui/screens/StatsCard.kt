package edu.itvo.mygestordefinanzas.presentacion.ui.screens


import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.unit.dp
import edu.itvo.mygestordefinanzas.domain.model.Transaction
import edu.itvo.mygestordefinanzas.domain.model.TransactionType

@Composable
fun StatsCard(transactions: List<Transaction>) {

    val income = transactions
        .filter { it.type == TransactionType.INCOME }
        .sumOf { it.amount }

    val expense = transactions
        .filter { it.type == TransactionType.EXPENSE }
        .sumOf { it.amount }

    val balance = income - expense

    Card(
        modifier = Modifier.fillMaxWidth(),
        elevation = CardDefaults.cardElevation(6.dp),
        border = BorderStroke(
            1.dp,
            MaterialTheme.colorScheme.outline
        ),
        colors = CardDefaults.cardColors(
            containerColor = MaterialTheme.colorScheme.surface
        )
    )
    {
        Column(modifier = Modifier.padding(20.dp)) {

            Text(
                text = "Resumen",
                style = MaterialTheme.typography.titleMedium
            )

            Spacer(Modifier.height(12.dp))

            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.SpaceBetween
            ) {

                Column {
                    Text(
                        text = "Ingresos",
                        style = MaterialTheme.typography.bodySmall,
                        color = MaterialTheme.colorScheme.onSurfaceVariant
                    )
                    Text(
                        text = "+ $${income}",
                        color = MaterialTheme.colorScheme.primary,
                        style = MaterialTheme.typography.titleMedium
                    )
                }

                Column {
                    Text(
                        text = "Egresos",
                        style = MaterialTheme.typography.bodySmall,
                        color = MaterialTheme.colorScheme.onSurfaceVariant
                    )
                    Text(
                        text = "- $${expense}",
                        color = MaterialTheme.colorScheme.error,
                        style = MaterialTheme.typography.titleMedium
                    )
                }

                Column(horizontalAlignment = Alignment.End) {
                    Text(
                        text = "Balance",
                        style = MaterialTheme.typography.bodySmall,
                        color = MaterialTheme.colorScheme.onSurfaceVariant
                    )

                    Text(
                        text = "$$balance",
                        style = MaterialTheme.typography.headlineSmall,
                        color = if (balance >= 0)
                            MaterialTheme.colorScheme.primary
                        else
                            MaterialTheme.colorScheme.error
                    )
                }

            }
        }
    }
}


